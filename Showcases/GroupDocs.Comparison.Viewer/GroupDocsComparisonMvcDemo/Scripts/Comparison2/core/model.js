define("core/model",
    [
        "core/model/model.compare",
        "core/model/model.changes",
        "core/model/model.documentdetails"
    ],
    function (
        compare,
        changes,
        documentDetails
    ) {
        var
            model = {
                compare: compare,
                changes: changes,
                documentDetails: documentDetails
            };
        return model;
    });