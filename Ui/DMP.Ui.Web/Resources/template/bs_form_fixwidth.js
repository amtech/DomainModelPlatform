var jsrenderBoostrapFormContent = '<div id="{{: control_id}}" class="form-group-sm col-xs-12 col-sm-4 col-lg-3 col-ie7-4" rel-modelindex="{{: modelindex}}">' +
  '<label class="control-label" for="">{{: content_label}}</label>' +
  '<div class="form-control-content">' +
  '<input type="text" class="form-control-simplified" />' +
  '</div>' +
  '</div>';
var jsrenderBoostrapFormContentTime = '<div id="{{: control_id}}" class="form-group-sm col-xs-12 col-sm-4 col-lg-3 col-ie7-4 hidden-ie7" rel-modelindex="{{: modelindex}}">' +
  '<label class="control-label" for="">{{: content_label}}</label>' +
  '<div class="form-control-content">' +
  '<div class="input-daterange input-group" rel-type="timecontent" id="datepicker">' +
  '<input type="text" class="input form-control" name="start" />' +
  '<span class="input-group-addon">至</span>' +
  '<input type="text" class="input form-control" name="end" />' +
  '</div>' +
  '</div>' +
  '</div>';
var jsrenderBoostrapFormContentMultiselect = '<div id="{{: control_id}}" class="form-group-sm col-xs-12 col-sm-4 col-lg-3 col-ie7-4 hidden-ie7" rel-modelindex="{{: modelindex}}">' +
  '<label class="control-label" for="">{{: content_label}}</label>' +
  '<div class="form-control-content">' +
  '<select class="control-multiselect form-control"  multiple="multiple">' +
  '{{for options}}' +
  '<option value="{{:value}}">{{:index}}</option>' +
  '{{/for}}' +
  '</select>' +
  '</div>' +
  '</div>';
modelcollection.add("jsrenderBoostrapFormContentMultiselect", jsrenderBoostrapFormContentMultiselect);
modelcollection.add("jsrenderBoostrapFormContentTime", jsrenderBoostrapFormContentTime);
modelcollection.add("jsrenderBoostrapFormContent", jsrenderBoostrapFormContent);
