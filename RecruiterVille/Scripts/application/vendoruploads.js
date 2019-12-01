function getuploadedvendorslist() {
    showloading();
    $('#tbodyvendoruploads tr').remove();

    $.ajax({
        type: "GET",
        url: "/recruiter/getvendoruploadslist",
        dataType: "json",
        success: function (data) {
            var ishavingvendors = true;

            if (data != null) {
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var tr = $('<tr />');

                        $(tr).append('<td><input type="hidden" id="hiddenvendoruploadid" value="' + data[i].VendorUploadId + '" /></td>' +
                                    '<td><a href="' + data[i].FilePath + '" target="_blank">Download File</a></td>' +
                                    '<td>' + data[i].TotalRecords + '</td>' +
                                    '<td>' + data[i].ValidRecords + '</td>' +
                                    '<td>' + data[i].InvalidRecords + '</td>' +
                                    '<td>' + data[i].UploadedBy + '</td>' +
                                    '<td>' + data[i].UploadedDate + '</td>');
                        $('#tbodyvendoruploads').append(tr);
                    }
                }
                else {
                    ishavingvendors = false;
                }
            }
            else {
                ishavingvendors = false;
            }

            if (!ishavingvendors) {
                var tr = $('<tr />');
                $(tr).append('<td colspan="7">No uploaded vendors found.</td>');
                $('#tbodyvendoruploads').append(tr);
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}