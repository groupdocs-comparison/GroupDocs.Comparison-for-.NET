define("core/model/model.documentdetails",
    ["ko"],
    function (ko) {
        var
            documentDetails = function () {
                var self = this;
                self.guid = ko.observable();
                self.name = ko.observable();
                self.supported = ko.observable();
            };

        documentDetails.fromDto = function (dto) {
            var item = new documentDetails().guid(dto.guid);
            item.name(dto.name)
                .supported(dto.supported);
            return item;
        };
        documentDetails.getDtoId = function (dto) { return dto.guid; };
        return documentDetails;
    });