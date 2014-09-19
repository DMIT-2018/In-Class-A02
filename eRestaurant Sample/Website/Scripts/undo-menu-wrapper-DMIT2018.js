/// <reference path="jquery-1.10.2.js" />
/// <reference path="bootstrap.js" />

/* Remove float styling that was injected for the menu control */

$(function () {
    // Isolate the context for applying Bootstrap styling
    $('#SiteNav').next().removeAttr('style');
});