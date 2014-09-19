/// <reference path="jquery-1.10.2.js" />
/// <reference path="bootstrap.js" />

/* Inject styling on Form elements, to leave markup in .aspx "clean" */

$(function () {
    // Isolate the context for applying Bootstrap styling
    var target = $('div[data-style=bootstrap]');
    target.addClass('container');
    $('input,textarea,select', target).addClass('form-control');
    $('label', target).addClass('col-sm-2');
    $('label', target).addClass('control-label');
    $('fieldset[data-style=inline]', target).addClass('form-inline');
    $('fieldset[data-style=btn] a', target).addClass('btn');
    $('fieldset[data-style=btn] a', target).addClass('btn-primary');
    $('fieldset', target).addClass('row');
    $('fieldset', target).addClass('panel');

    // General styling to use form-horizontal
    $('form').addClass('form-horizontal');
});