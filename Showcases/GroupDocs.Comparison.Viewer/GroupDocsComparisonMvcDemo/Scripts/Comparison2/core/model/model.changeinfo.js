define("core/model/model.changeinfo",
    ["ko", "core/config"],
    function (ko, config) {
        var
            changeInfo = function () {
                var self = this;
                self.id = ko.observable();
                self.type = ko.observable();
                self.action = ko.observable();
                self.page = ko.observable();
                self.box = ko.observable();
                self.text = ko.observable();
                self.active = ko.observable(false);

                self.width = ko.observable();
                self.height = ko.observable();
                self.left = ko.observable();
                self.top = ko.observable();

                self.isApproved = ko.computed(function () {
                    return this.action() === config.comparisonAction.accept;
                }, self);

                self.isRejected = ko.computed(function() {
                    return this.action() === config.comparisonAction.reject;
                }, self);

                self.accept = function() {
                    self.action(config.comparisonAction.accept);
                };
                
                self.reject = function () {
                    self.action(config.comparisonAction.reject);
                };

                self.reset = function () {
                    self.action(config.comparisonAction.none);
                };
            };

        changeInfo.fromDto = function (dto) {
            var item = new changeInfo().id(dto.Id);
            item.type("Inserted")
                .action("None")
                .page(dto.Page)
                .box(dto.Box)
                .text(dto.Text);
            return item;
        };
        changeInfo.getDtoId = function (dto) { return dto.Id; };
        return changeInfo;
    });