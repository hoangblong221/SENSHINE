(function ($) {
    "use strict";

    $(document).ready(function () {
        $("#userScenario").jsGrid({
            width: "100%",
            filtering: true,
            editing: true,
            inserting: true,
            sorting: true,
            paging: true,
            autoload: true,
            pageSize: 15,
            pageButtonCount: 5,
            deleteConfirm: "Bạn có muốn xóa người dùng này?",
            controller: db,
            fields: [
                { name: "Id", type: "number", width: 50 },
                { name: "UserName", title: "Người Dùng", type: "text", width: 100 },
                { name: "FullName", title: "Họ & Tên", type: "text", width: 150 },
                { name: "Phone", title: "Điện Thoại", type: "text", width: 100 },
                { name: "BirthDate", title: "Ngày Sinh", type: "text", width: 100 },
                { name: "Address", title: "Địa Chỉ", type: "text", width: 200 },
                { name: "Roles", title: "Chức Vụ", type: "text", width: 100 },
                { type: "control", width: 100 }
            ]
        });
    });
})(jQuery);
