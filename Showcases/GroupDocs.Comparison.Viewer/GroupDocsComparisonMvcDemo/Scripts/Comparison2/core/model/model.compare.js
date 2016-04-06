define("core/model/model.compare",
    ["ko"],
    function (ko) {
        var
            compare = function () {
                var self = this;
                self.jobId = ko.observable();
            };

        compare.fromDto = function(dto) {
            var item = new compare().jobId(dto.job_id);
            return item;
        };
        compare.getDtoId = function (dto) { return dto.job_id; };
        return compare;
    });