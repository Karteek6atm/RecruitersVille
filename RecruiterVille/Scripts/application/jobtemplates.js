function getjobtemplateslist() {
    showloading();
    $('#tbodyjobs tr').remove();

    $.ajax({
        type: "GET",
        url: "/job/getjobtemplateslist",
        dataType: "json",
        success: function (data) {
            var ishavingjobs = true;

            if (data != null) {
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var tr = $('<tr />');
                        var pay = '';
                        var duration = '';
                        var experience = '';

                        if (data[i].MinPayRate > 0 || data[i].MaxPayRate > 0) {
                            pay = data[i].PayCurrencySign + ' ' + data[i].MinPayRate + ' - ' + data[i].MaxPayRate + '/' + data[i].PayTypeName;
                        }

                        if (data[i].JobDuration > 0) {
                            duration = data[i].JobDuration + ' ' + data[i].JobDurationTypeName;
                        }

                        if (data[i].MinExp > 0 && data[i].MaxExp > 0) {
                            experience = data[i].MinExp + ' - ' + data[i].MaxExp + ' Yrs';
                        }
                        else if (data[i].MinExp > 0) {
                            experience = data[i].MinExp + ' Yrs';
                        }
                        else if (data[i].MaxExp > 0) {
                            experience = data[i].MaxExp + ' Yrs';
                        }

                        $(tr).append('<td>' + (i + 1) + '<input type="hidden" id="hiddenjobtemplateid" value="' + data[i].JobTemplateId + '" /></td>' +
                                    '<td>' + data[i].TemplateName + '</td>' +
                                    '<td>' + data[i].JobTitle + '</td>' +
                                    '<td>' + pay + '</td>' +
                                    '<td>' + duration + '</td>' +
                                    '<td>' + experience + '</td>' +
                                    '<td>' + data[i].IndustryName + '</td>' +
                                    '<td>' + data[i].TechnologyNames + '</td>' +
                                    '<td><a href="/job/editjobtemplate/' + data[i].JobTemplateId + '" id="aeditjobtemplate"> <i class="fa fa-pencil"></i> Edit</a> &nbsp; <a href="javascript:void(0)" id="adeletejobtemplate" onclick="deletejobtemplate(this)"><i class="fa fa-trash-o"></i> Delete</a>'+
                                    ' &nbsp; <a href="/job/viewjobtemplate/' + data[i].JobTemplateId + '" id="aviewjobtemplate"><i class="fa fa-eye"></i> View</a></td>');
                       
                        $('#tbodyjobs').append(tr);
                    }
                }
                else {
                    ishavingjobs = false;
                }
            }
            else {
                ishavingjobs = false;
            }

            if (!ishavingjobs) {
                var tr = '<tr />';
                $(tr).append('<td colspan="9">No job templates found.</td>');
                $('#tbodyjobs').append(tr);
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}

function deletejobtemplate(obj) {
    var jobtemplateid = $(obj).closest('tr').find('#hiddenjobtemplateid').val();
    $("#hiddenselectedjobtemplateid").val(jobtemplateid);
    $("#textstatuscomments").val('');
    $('#modaldeletejobtemplate').modal();
}

function deleteconfirm() {
    hideallalerts();
    var jobtemplateid = $("#hiddenselectedjobtemplateid").val();
    var comments = $("#textcomments");
    var isvalid = true;

    if (validatetextbox(comments) == false) {
        isvalid = false;
    }

    if (jobtemplateid != "" && jobtemplateid != "0" && isvalid) {
        showloading();

        var input = [];
        input = {
            strJobTemplateId: jobtemplateid,
            Comments: comments.val().trim()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/job/deletejobtemplate",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    $("#hiddenselectedjobtemplateid").val('0');
                    $('#closemodaldeletejobtemplate').click();
                    getjobtemplateslist();
                }
                else {
                    showwarningalert(data.StatusMessage);
                }
                hideloading();
            },
            error: function (xhr) {
                hideloading();
                showerroralert(xhr.responseText);
            }
        });
    }
}