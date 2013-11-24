function JQGrid_ManageProduct(urlAction) {
    var grid = $("#gridReport");

    grid.jqGrid({
        url: urlAction,
        height: 'auto',
        rowNum: 10,
        datatype: 'json',
        rowList: [10, 20, 30],
        //loadonce: true,
        mtype: 'GET',
        colNames: ['Mã sp', 'Tên', 'Hình', 'Số lượng', 'Tình trạng', 'Thay đổi', 'Xóa'],
        colModel: [
            { name: 'Code', index: 'Code', width : '50px' },
            { name: 'Name', index: 'Name', width: '220px' },
            { name: 'Image1', index: 'Image1', classes: 'item-image' },
            { name: 'Quantity', index: 'Quantity', width: '50px' },
            { name: 'IsActive', index: 'IsActive' },
            { name: 'LinkUpdate', index: 'LinkUpdate', classes: 'item-updateLink' },
            { name: 'LinkDelete', index: 'LinkDelete', classes: 'item-deleteLink' }
        ],
        viewrecords: true,
        width: 937,
        
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