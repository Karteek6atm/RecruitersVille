function tabledata(table, callbackfunction) {
    var thead = $(table).find("thead")[0];

    $(table).addClass("tabledata");

    var pagesizediv = $(thead).find(".tablesetpaging")[0];

    $(pagesizediv).append('<select class="form-control dropselection">' +
                            '<option value="10" selected>10</option>' +
                            '<option value="25">25</option>' +
                            '<option value="50">50</option>' +
                            '<option value="100">100</option>' +
                            '</select>');

    $(table).find(".hasinput input[type='text']").keyup(function () {
        pageno = 1;
        callbackfunction();
    });

    $(table).find(".dropselection").change(function () {
        pageno = 1;
        pagesize = parseInt($(this).val());
        callbackfunction();
    });

    var headerrowslength = $(thead).find("tr").length;
    var mainheaderrow = $(thead).find("tr")[headerrowslength - 1];
    var headercolumns = $(mainheaderrow).find("th");

    for (var i = 0; i < headercolumns.length; i++) {
        var columnname = $(headercolumns[i]).html();
        var isrequiredsort = $(headercolumns[i]).attr("data-sort");

        if (isrequiredsort == "true") {
            var sortcolumnname = $(headercolumns[i]).attr("sort-name");
            
            if (sortcolumnname == sortcolumn) {
                if (sortorderby == "asc") {
                    $(headercolumns[i]).html('<a sort-order="' + sortcolumnname + '" class="tableorder" order="desc">' + columnname + ' <i class="fa fa-caret-up"   aria-hidden="true"></i></a>');
                }
                else {
                    $(headercolumns[i]).html('<a sort-order="' + sortcolumnname + '" class="tableorder" order="asc">' + columnname + ' <i class="fa fa-caret-down"   aria-hidden="true"></i></a>');
                }
            }
            else {
                $(headercolumns[i]).html('<a sort-order="' + sortcolumnname + '" class="tableorder" order="asc">' + columnname + ' <i class="fa fa-caret-down"   aria-hidden="true"></i></a>');
            }
        }
    }

    $(headercolumns).find(".tableorder").click(function () {
        sortcolumn = $(this).attr("sort-order");
        sortorderby = $(this).attr("order");

        $(headercolumns).find(".tableorder").find(".fa").removeClass("fa-caret-up").addClass("fa-caret-down");

        if (sortorderby == "asc") {
            $(this).attr("order", "desc");
            $(this).find(".fa").removeClass("fa-caret-down").addClass("fa-caret-up");
        }
        else {
            $(this).attr("order", "asc");
            $(this).find(".fa").removeClass("fa-caret-up").addClass("fa-caret-down");
        }
        pageno = 1;
        callbackfunction();
    });
}

function setuppaginglinks(tableid, tableloadfunction, pagenumber, pagesizes, totalarecords) {
    var totalpages = Math.ceil(totalarecords / pagesizes);
    var thead = $(tableid).find("thead")[0];
    var headerrowslength = $(thead).find("tr").length;
    var mainheaderrow = $(thead).find("tr")[headerrowslength - 1];
    var headercolumns = $(mainheaderrow).find("th").length;    var footerpagelabel = "";    var paginglinks = "";    var startindex = ((pagenumber - 1) * pagesizes) + 1;    var endindex = (pagenumber * pagesizes);    if (totalarecords == 1) {
        footerpagelabel = "Showing 1 of 1 record";
    }
    else {
        if (totalarecords <= endindex) {
            footerpagelabel = "Showing " + startindex + " to " + totalarecords + " of " + totalarecords + " records";
        }
        else {
            footerpagelabel = "Showing " + startindex + " to " + endindex + " of " + totalarecords + " records";
        }
    }    if (totalpages <= 3) {
        for (var i = 0; i < totalpages; i++) {
            if (pagenumber == (i + 1)) {
                paginglinks += "&nbsp;<a href='javascript:void(0)' class='tablepagenumber active' data-page='" + (i + 1) + "'>" + (i + 1) + "</a>&nbsp;";
            }
            else {
                paginglinks += "&nbsp;<a href='javascript:void(0)' class='tablepagenumber' data-page='" + (i + 1) + "'>" + (i + 1) + "</a>&nbsp;";
            }
        }
    }    else {
        if (pagenumber == 1) {
            for (var i = 0; i < 3; i++) {
                if (pagenumber == (i + 1)) {
                    paginglinks += "&nbsp;<a href='javascript:void(0)' class='tablepagenumber active' data-page='" + (i + 1) + "'>" + (i + 1) + "</a>&nbsp;";
                }
                else {
                    paginglinks += "&nbsp;<a href='javascript:void(0)' class='tablepagenumber' data-page='" + (i + 1) + "'>" + (i + 1) + "</a>&nbsp;";
                }
            }            paginglinks += "&nbsp;<a href='javascript:void(0)' data-page='2'>Next</a>&nbsp;";            paginglinks += "&nbsp;<a href='javascript:void(0)' data-page='" + totalpages + "'>Last</a>&nbsp;";
        }        else if (pagenumber == totalpages) {
            paginglinks += "&nbsp;<a href='javascript:void(0)' data-page='1'>First</a>&nbsp;";            paginglinks += "&nbsp;<a href='javascript:void(0)' data-page='" + (pagenumber - 1) + "'>Prev</a>&nbsp;";            for (var i = totalpages - 2; i <= totalpages; i++) {
                if (pagenumber == i) {
                    paginglinks += "&nbsp;<a href='javascript:void(0)' class='tablepagenumber active' data-page='" + (i) + "'>" + (i) + "</a>&nbsp;";
                }
                else {
                    paginglinks += "&nbsp;<a href='javascript:void(0)' class='tablepagenumber' data-page='" + (i) + "'>" + (i) + "</a>&nbsp;";
                }
            }
        }        else {
            paginglinks += "&nbsp;<a href='javascript:void(0)' data-page='1'>First</a>&nbsp;";            paginglinks += "&nbsp;<a href='javascript:void(0)' data-page='" + (pagenumber - 1) + "'>Prev</a>&nbsp;";            for (var i = pagenumber - 1; i <= pagenumber + 1; i++) {
                if (pagenumber == i) {
                    paginglinks += "&nbsp;<a href='javascript:void(0)' class='tablepagenumber active' data-page='" + (i) + "'>" + (i) + "</a>&nbsp;";
                }
                else {
                    paginglinks += "&nbsp;<a href='javascript:void(0)' class='tablepagenumber' data-page='" + (i) + "'>" + (i) + "</a>&nbsp;";
                }
            }            paginglinks += "&nbsp;<a href='javascript:void(0)' data-page='" + (pagenumber + 1) + "'>Next</a>&nbsp;";            paginglinks += "&nbsp;<a href='javascript:void(0)' data-page='" + totalpages + "'>Last</a>&nbsp;";
        }
    }
    $(thead).find('#displaypagenumbers').html(footerpagelabel);    $(thead).find('#paginglinks').html(paginglinks);
    $(thead).find("#paginglinks").find("a").click(function () {
        pageno = parseInt($(this).attr("data-page"));
        tableloadfunction();
    });
}