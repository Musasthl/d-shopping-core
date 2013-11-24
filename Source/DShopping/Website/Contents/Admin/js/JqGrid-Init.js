function JQGrid_ManageProduct(urlAction) {
    alert("aaa");
    var grid = $("#gridReport");
    grid.jqGrid({
        url: urlAction,
        height: 'auto',
        rowNum: 10,
        datatype: 'json',
        rowList: [10, 20, 30],
        loadonce: true,
        mtype: 'GET',
        colNames: ['Code', 'Name', 'Image', 'Quantity', 'IsActive', 'LinkUpdate', 'LinkDelete'],
        colModel: [
            { name: 'Code', index: 'Code' },
            { name: 'Name', index: 'Name', width: '120px' },
            { name: 'Image', index: 'Image' },
            { name: 'Quantity', index: 'Quantity', width: '98px' },
            { name: 'IsActive', index: 'IsActive' },
            { name: 'LinkUpdate', index: 'LinkUpdate' },
            { name: 'LinkDelete', index: 'LinkDelete' }
        ],
        viewrecords: true,
        width: 940,
        
        sortname: 'CreatedDate1',
        sortorder: 'desc',
        pager: '#ptoolbar',
        autoWidth: true,
        ignoreCase: true,       
    });
    grid.jqGrid('navGrid', '#ptoolbar',
        { del: false, add: false, edit: false },
        {},
        {},
        {},
        {
            multipleSearch: true,
            //multipleGroup:true,
            showQuery: true,
            caption: ' Advance Search',
        }
    );
    grid.jqGrid('filterToolbar', { searchOnEnter: false, defaultSearch: 'cn', ignoreCase: true });
    grid.jqGrid('sortableRows');

}