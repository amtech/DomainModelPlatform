var tableHeadBind = [{
  label:'partid',
  name: 'partid',
  index: 'partid',
  width: 200,
  frozen : true
}, {
  label:'partName',
  name: 'partName',
  index: 'partName',
  width: 200,
  frozen : true
}, {
  label:'partName',
  name: 'cartype',
  index: 'cartype',
  width: 200
}, {
  name: 'pordLoc',
  index: 'pordLoc'
}, {
  name: 'spec',
  index: 'spec'
}, {
  name: 'featurecode',
  index: 'featurecode'
}, {
  name: 'count',
  index: 'count'
}, {
  name: 'taxIncludeUnivalent',
  index: 'taxIncludeUnivalent'
}, {
  name: 'taxIncludeAmount',
  index: 'taxIncludeAmount'
}, {
  name: 'taxWithoutUnivalent',
  index: 'taxWithoutUnivalent'
}, {
  name: 'taxWithoutAmount',
  index: 'taxWithoutAmount'
}, {
  name: 'tax',
  index: 'tax'
}, {
  name: 'discountper',
  index: 'discountper'
}, {
  name: 'discount',
  index: 'discount'
}, {
  name: 'amout',
  index: 'amout'
}, {
  name: 'prodlabel',
  index: 'prodlabel'
}, {
  name: 'warehouse',
  index: 'warehouse'
}, {
  name: 'unit',
  index: 'unit'
}, {
  name: 'picnum',
  index: 'picnum'
}, {
  name: 'supply',
  index: 'supply'
}, {
  name: 'shelfno',
  index: 'shelfno',
  sortable: false
}, {
  name: 'remarks',
  index: 'remarks',
  sortable: false
}, {
  name: 'singleweight',
  index: 'singleweight',
  sortable: false
}, {
  name: 'fullweight',
  index: 'fullweight',
  sortable: false
}, {
  name: 'urgent',
  index: 'urgent',
  sortable: false
}, {
  name: 'shopassistants',
  index: 'shopassistants',
  sortable: false
}, {
  name: 'costprice',
  index: 'costprice',
  sortable: false
}];

var mydata = [];
for (var i = 0; i <= 100; i++) {
  mydata[i] = {
    partid: "$8M5G850" + i,
    partName: "水泵总成",
    cartype: "EQ1230 /紫罗兰",
    pordLoc: "正厂",
    spec: "&nbsp;",
    featurecode: "&nbsp;",
    count: "1",
    taxIncludeUnivalent: "200.00",
    taxIncludeAmount: "200.00",
    taxWithoutUnivalent: "170.94",
    taxWithoutAmount: "29.06",
    tax: "100",
    discountper: "0.00",
    discount: "0.00",
    amout: "200.00",
    prodlabel: "&nbsp;",
    warehouse: "&nbsp;",
    tounittal: "正品仓1",
    picnum: "只",
    supply: "&nbsp;",
    shelfno: "&nbsp; ",
    remarks: "&nbsp; ",
    singleweight: "210.00",
    fullweight: "210.00",
    urgent: "yes",
    shopassistants: "廖经理",
    costprice: "210.00"
  }
}
