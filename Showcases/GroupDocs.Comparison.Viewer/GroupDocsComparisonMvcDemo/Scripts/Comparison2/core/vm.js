define("core/vm",
    [
        "comparison-settings",
        "core/vm/vm.selector",
        "core/vm/vm.diffnavigator",
        "core/vm/vm.viewer",
        "core/vm/vm.progress",
        "core/vm/vm.embed"
    ],
    function (
        settings,
        selector,
        diffNavigator,
        viewer,
        progress,
        embed
    ) {
        return {
            selector: selector,
            diffNavigator: diffNavigator,
            viewer: viewer,
            progress: progress,
            embed: embed,
            localization: settings.localization
        };
    });