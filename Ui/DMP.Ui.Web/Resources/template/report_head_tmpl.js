  var jsrenderHeadModel =
    '{{if type=="input"}}' +
    '{{include tmpl="jsrenderBoostrapFormContent"/}}' +
    '{{else type=="time"}}' +
    '{{include tmpl="jsrenderBoostrapFormContentTime"/}}' +
    '{{else type=="multiselect"}}' +
    '{{include tmpl="jsrenderBoostrapFormContentMultiselect"/}}' +
    '{{/if}}';
  modelcollection.addmain("jsrenderHeadModel", jsrenderHeadModel);
