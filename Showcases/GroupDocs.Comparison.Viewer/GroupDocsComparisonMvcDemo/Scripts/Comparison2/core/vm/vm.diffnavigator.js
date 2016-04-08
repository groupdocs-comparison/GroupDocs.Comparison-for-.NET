define("core/vm/vm.diffnavigator",
    ["jquery",
        "ko",
        "lib/underscore",
        "core/config",
        "comparison-settings",
        "core/repository",
        "core/model/model.changes"
    ],
    function($, ko, _, config, settings, repository, mchanges) {
        var visible = ko.observable(false),
            data = ko.observable(),
            error = ko.observable(),
            searchFilter = ko.observable(""),
            resultDocId = ko.observable(""),
            activeChangeIndex = ko.observable(0),
            afterChangesApplied = ko.observable(null),
            
            errorHandler = function(e) {
                error(e);
            },

            activateChange = function (change) {
                var changes = data().changes();
                var oldChange = _.find(changes, function (c) { return c.active(); });
                if (oldChange) oldChange.active(false);
                activeChangeIndex(_.indexOf(changes, change));
                change.active(true);
            },
            gotoChange = function (offset) {
                var oldIndex = activeChangeIndex();
                var newIndex = oldIndex + offset;
                var changesCount = data().changes().length;
                if (changesCount === 0) return;
                if (newIndex < 0) newIndex = changesCount - 1;
                if (newIndex >= changesCount) newIndex = 0;
                var newChange = data().changes()[newIndex];

                activateChange(newChange);
            },
            setChanges = function(dtoChanges) {
                var changes = mchanges.fromDto(dtoChanges);
                data(changes);
                gotoChange(0);
                visible(true);
            },
            gotoPrevChange = function() {
                gotoChange(-1);
            },
            gotoNextChange = function() {
                gotoChange(1);
            },
            

            clearFilter = function() {
                searchFilter("");
            },
            setDocumentId = function(docId) {
                resultDocId(docId);
            },
            download = function(format) {
                var fileId = resultDocId();
                if (fileId !== "") {
                    var downloadUrl = repository.compare.getDownloadResultUrl(fileId, format);
                    window.location.href = downloadUrl;
                } else {
                    error("We have nothing to download. Please compare first.");
                }
            },
            resetInitialState = function() {
                visible(false);
                data(null);
                activeChangeIndex(0);
            },

            hasChangesForAccepting = ko.computed(function() {
                if (data() == null) return false;
                var changes = data().changes();
                return _.some(changes, function(item) {
                    return item.action() === config.comparisonAction.accept || item.action() === config.comparisonAction.reject;
                });
            }),

            changesForApplying = function() {
                if (data() == null) return false;
                var changes = data().changes();

                return _.filter(changes, function(item) {
                    return item.action() === config.comparisonAction.accept || item.action() === config.comparisonAction.reject;
                });
            },

            confirmAction = function(message, callback) {
                var modalSettings = {
                    title: "Confirmation",
                    message: message,
                    buttons: {}
                }
                modalSettings.buttons["Yes"] = {
                    'action': function() {
                        callback();
                    },
                    isYes: true
                };
                modalSettings.buttons["No"] = {
                    isNo: true
                };


                $.confirm(modalSettings);
                return false;
            },

            loadChanges = function (docId) {
                resultDocId(docId);
                data(null);
                repository.compare.getChanges(docId, setChanges, errorHandler);
            },

            applyAllChanges = function() {
                if (!hasChangesForAccepting()) return false;
                confirmAction("Are your sure that you want to apply all actions that you selected?", function () {
                    var changes = ko.toJS(changesForApplying());
                    $(".tab-content").scrollTop(0);
                    afterChangesApplied(null);
                    repository.compare.updateChanges(resultDocId(), changes).done(function () {
                        afterChangesApplied(resultDocId());
                    });
                });
                return false;
            },

            acceptAllChanges = function() {
                if (data() == null) return false;
                var changes = data().changes();

                _.each(changes, function(change) {
                    change.action(config.comparisonAction.accept);
                });
                data().changes.valueHasMutated();
                return false;
            },

            rejectAllChanges = function () {
                if (data() == null) return false;
                var changes = data().changes();

                _.each(changes, function (change) {
                    change.action(config.comparisonAction.reject);
                });
                data().changes.valueHasMutated();
                return false;
            },

            resetAllChanges = function() {
                if (!hasChangesForAccepting()) return false;
                confirmAction("Are your sure that you want to return all changes to initial state?", function () {
                    var changes = changesForApplying();
                    _.each(changes, function(change) {
                        change.action(config.comparisonAction.none);
                    });
                    data().changes.valueHasMutated();
                });
                return false;
            },

            init = function() {

            };

        init();

        var result = {
            visible: visible,
            gotoPrevChange: gotoPrevChange,
            gotoNextChange: gotoNextChange,
            activeChangeIndex: activeChangeIndex,
            activateChange: activateChange,
            loadChanges: loadChanges,
            setChanges: setChanges,
            error: error,
            data: data,
            searchFilter: searchFilter,
            clearFilter: clearFilter,
            download: download,
            resetInitialState: resetInitialState,
            hasChangesForAccepting: hasChangesForAccepting,
            
            applyAllChanges: applyAllChanges,
            afterChangesApplied: afterChangesApplied,

            resetAllChanges: resetAllChanges,
            acceptAllChanges: acceptAllChanges,
            rejectAllChanges: rejectAllChanges,

            setDocumentId: setDocumentId
        };

        result.filteredChanges = ko.computed(function() {
            if (data() == null) return [];
            var changes = data().changes();
            if (this.searchFilter() === "") return changes;
            var self = this;
            var filtered = _.filter(changes, function(change) {
                return change.text().toLowerCase().indexOf(self.searchFilter().toLowerCase()) !== -1;
            });
            return filtered;
        }, result).extend({ throttle: 400 });

        result.categorizedChanges = ko.computed(function () {
            var changes = this.filteredChanges();
            return [
                {
                    name: "Content Changes",
                    data: {
                        changes:
                            _.filter(changes, function (change) {
                                var type = change.type();
                                return type === config.changeType["insert"] || type === config.changeType["delete"];
                            })
                    }
                },
                {
                    name: "Style Changes",
                    data: {
                        changes: _.filter(changes, function (change) {
                            var type = change.type();
                            return type === config.changeType["styleChange"];
                        })
                    }
                }
            ];
        }, result),

        result.acceptRejectCount = ko.computed(function () {
            if (this.data() == null) return { accept: 0, reject: 0 };
            var changes = this.data().changes();
            var  grouped = _.countBy(changes, function(change) {
                if (change.action() === config.comparisonAction.accept) return "accept";
                if (change.action() === config.comparisonAction.reject) return "reject";
                return "";
            });

            grouped.reject = grouped.reject || 0;
            grouped.accept = grouped.accept || 0;

            return grouped;
        }, result);

        return result;
    });