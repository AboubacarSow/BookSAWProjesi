window.blazorHelpers = {
    initialize: function () {
        // Call your initialization function
        if (typeof initMyScripts === 'function') {
            initMyScripts();
        }
    }
};