$(document).ready(function () {
    $.templates('tmplSearchArea',
    '<div class="form-fixwidth">' +
                '{{for items}}' +
                '{{if type=="text"}}' +
                '{{include tmpl="tmplText"/}}' +
                '{{else type=="time"}}' +
                '{{include tmpl="tmplTime"/}}' +
                '{{else type=="multiselect"}}' +
                '{{include tmpl="tmplMultiSelect"/}}' +
                '{{/if}}' +
                '{{/for}}' +
    '</div>');
});
