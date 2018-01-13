var selectedId = "00000000-0000-0000-0000-000000000000";


var editone = $("#editone").text();
var addone = $("#addone").text();
var deleteone = $("#deleteone").text();
var checkeone = $("#checkone").text();
var updateone = $("#updateone").text();
var startone = $("#startone").text();
var stopone = $("#stopone").text();


var deletewaring = $("#deletewaring").text();
var deleteok = $("#deleteok").text();
var deletecancel = $("#deletecancel").text();
var selecttodelete = $("#selecttodelete").text();
var deletefailed = $("#deletefailed").text();


$(function () {
    $("#btnAdd").click(function () { add(); });
    $("#btnSave").click(function () { save(); });
    $("#btnDelete").click(function () { deleteMulti(); });
    $("#checkAll").click(function () { checkAll(this) });
    initTree();
});
//全选
function checkAll(obj) {
    $(".checkboxs").each(function () {
        if (obj.checked == true) {
            $(this).prop("checked", true)

        }
        if (obj.checked == false) {
            $(this).prop("checked", false)
        }
    });
};
//加载楼层树
function initTree() {
	$.jstree.destroy();
    $.ajax({
        type: "Get",
		url: "/Department/GetTreeData?_t=" + new Date().getTime(),    //获取数据的ajax请求地址
		success: function (data) {
			
			$.each(data, function (index, item) {
				selectedId = item.id;

			});

			loadTables(1, 10);
			/*
            $('#treeDiv').jstree({       //创建JsTtree
                'core': {
                    'data': data,        //绑定JsTree数据
                    "multiple": false    //是否多选
                },
                "plugins": ["state", "types", "wholerow"]  //配置信息
            })
            $("#treeDiv").on("ready.jstree", function (e, data) {   //树创建完成事件
                data.instance.open_all();    //展开所有节点
            });
            $("#treeDiv").on('changed.jstree', function (e, data) {   //选中节点改变事件
                var node = data.instance.get_node(data.selected[0]);  //获取选中的节点
                if (node) {
                    selectedId = node.id;
                    loadTables(1, 10);
                };
            });
			*/
        }
    });

}
//加载用户列表数据
function loadTables(startPage, pageSize) {
    $("#tableBody").html("");
    $("#checkAll").prop("checked", false);
    $.ajax({
        type: "GET",
        url: "/User/GetUserByDepartment?startPage=" + startPage + "&pageSize=" + pageSize + "&departmentId=" + selectedId + "&_t=" + new Date().getTime(),
        success: function (data) {
            $.each(data.rows, function (i, item) {
                var tr = "<tr>";
                tr += "<td align='center'><input type='checkbox' class='checkboxs' value='" + item.id + "'/></td>";
                tr += "<td>" + item.userName + "</td>";
                tr += "<td>" + (item.name == null ? "" : item.name) + "</td>";
                tr += "<td>" + (item.email == null ? "" : item.email) + "</td>";
                tr += "<td>" + (item.mobileNumber == null ? "" : item.mobileNumber) + "</td>";
                tr += "<td>" + (item.remarks == null ? "" : item.remarks) + "</td>";
				tr += "<td><button class='btn btn-info btn-xs' href='javascript:;' onclick='edit(\"" + item.id + "\")'><i class='fa fa-edit'></i> " + editone + " </button> <button class='btn btn-danger btn-xs' href='javascript:;' onclick='deleteSingle(\"" + item.id + "\")'><i class='fa fa-trash-o'></i> " + deleteone + " </button> </td>"
                tr += "</tr>";
                $("#tableBody").append(tr);
            })
            var elment = $("#grid_paging_part"); //分页插件的容器id
            if (data.rowCount > 0) {
                var options = { //分页插件配置项
                    bootstrapMajorVersion: 3,
                    currentPage: startPage, //当前页
                    numberOfPages: data.rowsCount, //总数
                    totalPages: data.pageCount, //总页数
                    onPageChanged: function (event, oldPage, newPage) { //页面切换事件
                        loadTables(newPage, pageSize);
                    }
                }
                elment.bootstrapPaginator(options); //分页插件初始化
            }
            loadRoles(data);
        }
    })
};
function loadRoles(data) {
    $("#Role").select2();
    var option = "";
    $.each(data.roles, function (i, item) {
        option += "<option value='" + item.id + "'>" + item.name + "</option>"
    })
    $("#Role").html(option);
}
//新增
function add() {
    $("#Id").val("00000000-0000-0000-0000-000000000000");
    $("#UserName").val("");
    $("#Password").val("");
    $("#Name").val("");
    $("#EMail").val("");
    $("#MobileNumber").val("");
    $("#Remarks").val("");
    $("#Role").select2("val", "");
    $("#Title").text(addone);
    //弹出新增窗体
    $("#editModal").modal("show");
};
//编辑
function edit(id) {
    $.ajax({
        type: "Get",
        url: "/User/Get?id=" + id + "&_t=" + new Date().getTime(),
        success: function (data) {
            $("#Id").val(data.id);
            $("#UserName").val(data.userName);
            $("#Password").val(data.password);
            $("#Name").val(data.name);
            $("#EMail").val(data.eMail);
            $("#mobileNumber").val(data.mobileNumber);
            $("#Remarks").val(data.remarks);
            var roleIds = [];
            if (data.userRoles) {
                $.each(data.userRoles, function (i, item) {
                    roleIds.push(item.roleId)
                });
                $("#Role").select2("val", roleIds);
            }
            $("#Title").text(editone)
            $("#editModal").modal("show");
        }
    })
};
//保存
function save() {
    var roles = "";
    if ($("#Role").val())
        roles = $("#Role").val().toString();
    var postData = { "dto": { "Id": $("#Id").val(), "UserName": $("#UserName").val(), "Password": $("#Password").val(), "Name": $("#Name").val(), "EMail": $("#EMail").val(), "MobileNumber": $("#MobileNumber").val(), "Remarks": $("#Remarks").val(), "DepartmentId": selectedId }, "roles": roles };
    $.ajax({
        type: "Post",
        url: "/User/Edit",
        data: postData,
        success: function (data) {
            if (data.result == "Success") {
                loadTables(1, 10)
                $("#editModal").modal("hide");
            } else {
                layer.tips(data.message, "#btnSave");
            };
        }
    });
};
//批量删除
function deleteMulti() {
    var ids = "";
    $(".checkboxs").each(function () {
        if ($(this).prop("checked") == true) {
            ids += $(this).val() + ","
        }
    });
    ids = ids.substring(0, ids.length - 1);
	if (ids.length == 0) {
		layer.alert(selecttodelete);
        return;
    };
    //询问框
	layer.confirm(deletewaring, {
		btn: [deleteok, deletecancel],
		title: false
    }, function () {
        var sendData = { "ids": ids };
        $.ajax({
            type: "Post",
            url: "/User/DeleteMuti",
            data: sendData,
            success: function (data) {
                if (data.result == "Success") {
                    loadTables(1, 10)
                    layer.closeAll();
                }
                else {
					layer.alert(deletefailed);
                }
            }
        });
    });
};
//删除单条数据
function deleteSingle(id) {
	layer.confirm(deletewaring, {
		btn: [deleteok, deletecancel],
		title: deleteone
	}, function () {
        $.ajax({
            type: "POST",
            url: "/User/Delete",
            data: { "id": id },
            success: function (data) {
                if (data.result == "Success") {
                    loadTables(1, 10)
                    layer.closeAll();
                }
				else {
					layer.alert(deletefailed);
                }
            }
        })
    });
};
