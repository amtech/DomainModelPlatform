var tableHeadList = ['零件编码',
  '零件名称',
  '车型',
  '产地',
  '规格',
  '特征码',
  '数量',
  '含税单价',
  '含税金额',
  '不含税单价',
  '不含税金额',
  '税额',
  '折扣率',
  '折扣金额',
  '实际销售金额',
  '厂牌',
  '仓库',
  '单位',
  '图号',
  '供应商',
  '货位',
  '备注',
  '单重',
  '总重',
  '急件',
  '导购员',
  '成本价'
];
var tableHeadBind = [{
    label: '',
    name: 'partid',
    index: 'partid',
    width: 350
}, {
    name: 'partName',
    index: 'partName',
    width: 300
}, {
    name: 'cartype',
    index: 'cartype',
    width: 200
}, {
    name: 'pordLoc',
    index: 'pordLoc',
    width: 200
}, {
    name: 'spec',
    index: 'spec',
    width: 200
}, {
    name: 'featurecode',
    index: 'featurecode',
    width: 200
}, {
    name: 'count',
    index: 'count',
    width: 200
}, {
    name: 'taxIncludeUnivalent',
    index: 'taxIncludeUnivalent',
    width: 200
}, {
    name: 'taxIncludeAmount',
    index: 'taxIncludeAmount',
    width: 200
}, {
    name: 'taxWithoutUnivalent',
    index: 'taxWithoutUnivalent',
    width: 200
}, {
    name: 'taxWithoutAmount',
    index: 'taxWithoutAmount',
    width: 200
}, {
    name: 'tax',
    index: 'tax',
    width: 200
}, {
    name: 'discountper',
    index: 'discountper',
    width: 200
}, {
    name: 'discount',
    index: 'discount',
    width: 200
}, {
    name: 'amout',
    index: 'amout',
    width: 200
}, {
    name: 'prodlabel',
    index: 'prodlabel',
    width: 200
}, {
    name: 'warehouse',
    index: 'warehouse',
    width: 200
}, {
    name: 'unit',
    index: 'unit',
    width: 200
}, {
    name: 'picnum',
    index: 'picnum',
    width: 200
}, {
    name: 'supply',
    index: 'supply',
    width: 200
}, {
    name: 'shelfno',
    index: 'shelfno',
    width: 200,
    sortable: false
}, {
    name: 'remarks',
    index: 'remarks',
    width: 200,
    sortable: false
}, {
    name: 'singleweight',
    index: 'singleweight',
    width: 200,
    sortable: false
}, {
    name: 'fullweight',
    index: 'fullweight',
    width: 200,
    sortable: false
}, {
    name: 'urgent',
    index: 'urgent',
    width: 200,
    sortable: false
}, {
    name: 'shopassistants',
    index: 'shopassistants',
    width: 200,
    sortable: false
}, {
    name: 'costprice',
    index: 'costprice',
    width: 200,
    sortable: false
}];

var mydata = [];
for (var i = 0; i <= 50; i++) {
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
