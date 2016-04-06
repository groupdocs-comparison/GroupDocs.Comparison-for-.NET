define("core/model/model.changes",
    ["ko",
     "lib/underscore",
     "core/model/model.changeinfo"],
    function (ko, _, changeInfo) {
        var
            changes = function () {
                var self= this;
                self.resultFileId = ko.observable(),
                self.changes = ko.observableArray([]);
                self.changesForPage = function(index) {
                    return _.filter(this.changes(), function(c) {
                        return c.page() && c.page().Id === index;
                    });
                }.bind(self);

            };

        changes.fromDto = function (dto) {
            var item = new changes();
            var items = _.map(dto.Changes, function(dtoChangeInfo) {
                return changeInfo.fromDto(dtoChangeInfo);
            });
            item.resultFileId(dto.ResultFileId);
            item.changes(items);
            return item;
        };
        
        changes.getDtoId = function (dto) { return dto.ResultFileId; };
        return changes;
    });