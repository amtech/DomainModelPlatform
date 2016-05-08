$(document).ready(function () {
    if ($.render.tmplMultiSelect == undefined) {
        $.templates('tmplMultiSelect', '<div class="form-group-sm col-xs-12 col-sm-4 col-lg-3 col-ie7-4 hidden-ie7">' +
            '<label class="control-label" for="">{{: contentLabel}}</label>' +
            '<div class="form-control-content">' +
                '<select class="control-multiselect form-control" multiple="multiple">' +
                '</select>' +
            '</div>' +
        '</div>');
    }

    if ($.render.tmplText == undefined) {
        $.templates('tmplText', '<div class="form-group-sm col-xs-12 col-sm-4 col-lg-3 col-ie7-4">' +
            '<label class="control-label" for="">{{: contentLabel}}</label>' +
            '<div class="form-control-content">' +
                '<input type="text" class="form-control-simplified {{: addclass}}" />' +
            '</div>' +
        '</div>');
    }
    if ($.render.tmplTime == undefined) {
        $.templates('tmplTime', '<div class="form-group-sm col-xs-12 col-sm-4 col-lg-3 col-ie7-4 hidden-ie7">' +
            '<label class="control-label" for="">{{: contentLabel}}</label>' +
            '<div class="form-control-content">' +
                '<div class="input-daterange input-trio" id="{{: contentid}}">' +
                    '<span class="input-trio-btn pull-left">' +
                        '<input type="text" class="form-control" name="start" />' +
                    '</span>' +
                    '<span class="input-trio-btn pull-right">' +
                        '<input type="text" class="form-control" name="end" />' +
                    '</span>' +
                    '<span class="input-trio-addon input-trio-body">to</span>' +
                '</div>' +
            '</div>' +
        '</div>');
    }
});