function getprofileslist() {
    showloading();
    $('#tbodyprofiles tr').remove();

    $.ajax({
        type: "GET",
        url: "/profile/getprofileslist",
        dataType: "json",
        success: function (data) {
            var ishavingprofiles = true;

            if (data != null) {
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var tr = $('<tr />');
                        var name = data[i].FirstName;

                        if(data[i].LastName!=""){
                            name = name + " " + data[i].LastName;
                        }

                        var experience = '';

                        if (data[i].ExpYears == 0 && data[i].ExpMonths == 0) {
                            experience = 'Fresher';
                        }
                        else if (data[i].ExpMonths == 0) {
                            experience = data[i].ExpYears + ' Years';
                        }
                        else if (data[i].ExpYears == 0) {
                            experience = data[i].ExpMonths + ' Months';
                        }
                        else {
                            experience = data[i].ExpYears + ' Years - ' + data[i].ExpMonths + ' Months';
                        }

                        $(tr).append('<td>' + (i + 1) + '<input type="hidden" id="hiddenprofileid" value="' + data[i].ProfileId + '" /></td>' +
                                    '<td>' + name + '</td>' +
                                    '<td>' + data[i].EmailId + '</td>' +
                                    '<td>' + data[i].MobileNumber + '</td>' +
                                    '<td>' + experience + '</td>' +
                                    '<td>' + data[i].Industry + '</td>' +
                                    '<td>' + data[i].Skills + '</td>' +
                                    '<td><a href="' + data[i].Resume + '" target="_blank" id="aresumedownload"> Download</a></td>' +
                                    '<td><a href="/profile/edit/' + data[i].ProfileId + '" id="aeditprofile"> <i class="fa fa-pencil"></i> Edit</a> &nbsp; <a href="javascript:void(0)" id="achangeprofilestatus" onclick="changeprofilestatus(this)"><i class="fa fa-trash-o"></i> Change Status</a>' +
                                    ' &nbsp; <a href="/profile/view/' + data[i].ProfileId + '" id="aviewprofile"><i class="fa fa-eye"></i> View</a></td>');

                        $('#tbodyprofiles').append(tr);
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
                var tr = '<tr />';
                $(tr).append('<td colspan="9">No profiles found.</td>');
                $('#tbodyprofiles').append(tr);
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}

function changeprofilestatus(obj) {

}