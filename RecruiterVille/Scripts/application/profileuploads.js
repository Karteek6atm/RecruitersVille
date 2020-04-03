function getuploadedprofileslist() {
    showloading();
    $('#tbodyprofileuploads tr').remove();

    $.ajax({
        type: "GET",
        url: "/profile/getprofileuploadslist",
        dataType: "json",
        success: function (data) {
            var ishavingprofiles = true;

            if (data != null) {
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var tr = $('<tr />');

                        $(tr).append('<td><input type="hidden" id="hiddenprofileuploadid" value="' + data[i].ProfileUploadId + '" /></td>' +
                                    '<td><a href="' + data[i].FilePath + '" target="_blank">Download File</a></td>' +
                                    '<td>' + data[i].TotalRecords + '</td>' +
                                    '<td>' + data[i].ValidRecords + '</td>' +
                                    '<td>' + data[i].InvalidRecords + '</td>' +
                                    '<td>' + data[i].UploadedBy + '</td>' +
                                    '<td>' + data[i].UploadedDate + '</td>');
                        $('#tbodyprofileuploads').append(tr);
                    }
                }
                else {
                    ishavingprofiles = false;
                }
            }
            else {
                ishavingprofiles = false;
            }

            if (!ishavingprofiles) {
                var tr = $('<tr />');
                $(tr).append('<td colspan="7">No uploaded resumes found.</td>');
                $('#tbodyprofileuploads').append(tr);
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}