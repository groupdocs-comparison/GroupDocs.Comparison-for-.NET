define("core/repository",
    [
       "core/repository/repository.compare" 
    ],
    function (
        compare
    ) {
        return {
            compare: compare
        };
    });