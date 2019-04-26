var selectedId = "00000000-0000-0000-0000-000000000000";
var intervalId;

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
	$("#btnCheckAll").click(function () { sendcheckall() });

	$("#btnStartAll").click(function () { sendstartall() });
	$("#btnStopAll").click(function () { sendstopall() });
	$("#btnUpdateSetupAll").click(function () { sendupdatesetupall() });
	startCheckingTimer();
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
    //$.jstree.destroy();
	$.ajax({
		type: "Get",
		url: "/Department/GetTreeData?_t=" + new Date().getTime(),    //获取数据的ajax请求地址
		success: function (data) {
			
			selectedId = $.session.get('select_deparmentid')
			if (selectedId == undefined) {
			
				selectedId = data[0].id;
			}
						

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
        url: "/Terminal/GetTerminalByDepartment?startPage=" + startPage + "&pageSize=" + pageSize + "&departmentId=" + selectedId + "&_t=" + new Date().getTime(),
		dataType: "json",
		success: function (data) {

			console.log(data);
            $.each(data.rows, function (i, item) {
                var tr = "<tr>";
				tr += "<td align='center'><input type='checkbox' class='checkboxs' value='" + item.id + "'/></td>";
				tr += "<td>" + (item.ip == null ? "" : item.ip) + "</td>";
				tr += "<td>" + (item.positionX) + "</td>";
				tr += "<td>" + (item.positionY) + "</td>";
				tr += "<td>" + (item.desc) + "</td>";
				tr += "<td><button class='btn btn-info btn-xs' href='javascript:;' onclick='edit(\"" + item.id + "\")'><i class='fa fa-edit'></i>" + editone + "</button> <button class='btn btn-danger btn-xs' href='javascript:;' onclick='deleteSingle(\"" + item.id + "\")'><i class='fa fa-trash-o'></i> " + deleteone + " </button> <button class='btn btn-info btn-xs' href='javascript:;' onclick='checkSingle(\"" + item.id + "\")'>" + checkeone + " </button>  </td>"
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
        }
    })
};
//新增
function add() {
    $("#Id").val("00000000-0000-0000-0000-000000000000");
    $("#ip").val("");
	$("#PositionX").val("");
	$("#PositionY").val("");
	$("#desc").val("");
    $("#Title").text(addone);
    //弹出新增窗体
    $("#editModal").modal("show");
};
//编辑
function edit(id) {
    $.ajax({
        type: "Get",
        url: "/Terminal/Get?id=" + id + "&_t=" + new Date().getTime(),
        success: function (data) {
            $("#Id").val(data.id);
			$("#ip").val(data.ip);
			$("#PositionX").val(data.positionX);
			$("#PositionY").val(data.positionY);
            $("#desc").val(data.desc);
			$("#Title").text(editone)
            $("#editModal").modal("show");
        }
    })
};


function checkresult(data) {
	$("#tableconnectedBody").empty();
	
	$.each(data.ips, function (i, item) {
		var tr = "<tr>";
		tr += "<td align='center'><input type='checkbox' class='checkboxs' value='" + item.mId + "'/></td>";
		tr += "<td>" + (item.mId === null ? "" : item.mId) + "</td>";

		var reg = new RegExp("\\.", "g");
		var replacedId = item.mId.replace(reg , "_");

        tr += "<td><div id='rate_input_" + replacedId + "'/>" + "</td>";
        tr += "<td><div id='gain_input_" + replacedId + "'/>" + "</td>";

		if (item.mIsStart) {
			tr += "<td><button class='btn btn-info btn-xs' href='javascript:;' onclick='updatesetup(\"" + item.mId + "\")'> " + updateone + " </button> <button class='btn btn-info btn-xs' href='javascript:;' onclick='stopterminal(\"" + item.mId + "\")'> " + stopone +" </button>  </td>"

		}
		else {
			tr += "<td><button class='btn btn-info btn-xs' href='javascript:;' onclick='updatesetup(\"" + item.mId + "\")'> " + updateone + " </button> <button class='btn btn-info btn-xs' href='javascript:;' onclick='startterminal(\"" + item.mId + "\")'>  " + startone + " </button> </td>"

		}

		tr += "</tr>";
		$("#tableconnectedBody").append(tr);

		$('#rate_input_' + replacedId).text(item.mRate);
		$('#gain_input_' + replacedId).text(item.mGain);


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
}

function updatesetup(ip) {


	var reg = new RegExp("\\.", "g");
	var replacedId =  ip.replace(reg, "_");
	//var rate = $('#rate_input_' + replacedId).val();
    //var gain = $('#gain_input_' + replacedId).val();
    var rate = $('#rate_input').val();
    var gain = $('#gain_input').val();
	
	$.ajax({
		type: "Get",
		url: "/Terminal/UpdateSetup?ip=" + ip + "&rate=" + rate + "&gain=" + gain + "&_t=" + new Date().getTime(),
		success: checkresult
	})
}
function startterminal(ip) {
    
	$.ajax({
		type: "Get",
		url: "/Terminal/StartTerminal?ip=" + ip + "&_t=" + new Date().getTime(),
		success: checkresult
	})
}
function stopterminal(ip) {
 
	$.ajax({
		type: "Get",
		url: "/Terminal/StopTerminal?ip=" + ip + "&_t=" + new Date().getTime(),
		success: checkresult
	})
}





function checkresultupdate(data) {
	checkresult(data);

	alert("Setup OK");

}
function sendupdatesetupall() {


	var rate = $('#rate_input').val();
	var gain = $('#gain_input').val();
	$.ajax({
		type: "Get",
		url: "/Terminal/UpdateSetupAll?departmentId=" + selectedId + "&rate=" + rate + "&gain=" + gain + "&_t=" + new Date().getTime(),
		success: checkresultupdate
	})
}
function sendstartall() {
	$.ajax({
		type: "Get",
		url: "/Terminal/StartAll?departmentId=" + selectedId + "&_t=" + new Date().getTime(),
		success: checkresult
	})
}
function sendstopall() {
	$.ajax({
		type: "Get",
		url: "/Terminal/StopAll?departmentId=" + selectedId + "&_t=" + new Date().getTime(),
		success: checkresult
	})
}


function checkSingle(id) {
	$.ajax({
		type: "Get",
		url: "/Terminal/Check?id=" + id + "&_t=" + new Date().getTime(),
		success: checkresult
	})
}


function sendcheckall() {
	$.ajax({
		type: "Get",
		url: "/Terminal/CheckAll?departmentId=" + selectedId + "&_t=" + new Date().getTime(),
		success: checkresult
	})
}

//保存
function save() {
    var roles = "";
    if ($("#Role").val())
		roles = $("#Role").val().toString();
	
	var postData = { "dto": { "Id": $("#Id").val(), "DepartmentId": selectedId, "ip": $("#ip").val(), "PositionX": $("#PositionX").val(), "PositionY": $("#PositionY").val(), "desc": $("#desc").val() }};
    $.ajax({
        type: "Post",
        url: "/Terminal/Edit",
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
            url: "/Terminal/DeleteMuti",
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
		type: 0,
		btn: [deleteok, deletecancel],
		title: deleteone
    }, function () {
        $.ajax({
            type: "POST",
            url: "/Terminal/Delete",
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




function startCheckingTimer() {
	
	intervalId = setInterval(
		function () {

			$.ajax({
				type: "GET",
				url: "/Terminal/GetOnLineTerminals",
				success: function (data) {
					checkresult(data);
				}
			});
		},

		1000
	);
}

function stopCheckingTimer() {

	clearInterval(intervalId);
}
