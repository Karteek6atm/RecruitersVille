var geoplugindata;

$(document).ready(function () {
    $.getJSON('http://www.geoplugin.net/json.gp?jsoncallback=?', function (data) {
        geoplugindata = data;
        GetPackages();
    });
});

function GetPackages() {
    hideallalerts();
    showloading();

    var input = [];
    input = {
        currency: geoplugindata.geoplugin_currencyCode
    };

    $.ajax({
        type: "POST",
        data: (input),
        url: "/account/getpackages",
        dataType: "json",
        success: function (data) {
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    var packagedetails = data[i];
                    var divpackage = '';
                    var features = '';
                    var price = '';

                    if (packagedetails.FeaturesList.length > 0) {
                        for (var k = 0; k < packagedetails.FeaturesList.length; k++) {
                            var feature = packagedetails.FeaturesList[k];
                            if (feature.FeatureId == 1 || feature.FeatureId == 6) {
                                if (feature.Value == 0) {
                                    features = features + '<li><strong>No</strong> ' + feature.FeatureName + ' <br> + <br> <small>' + feature.Description + '</small></li>';
                                }
                                else {
                                    features = features + '<li><strong>' + feature.Value + '</strong> ' + feature.FeatureName + ' <br> + <br> <small>' + feature.Description + '</small></li>';
                                }
                            }
                            else if (feature.FeatureId == 5) {
                                features = features + '<li><strong>' + feature.Value + '</strong> ' + feature.Description + '</li>';
                            }
                            else if (feature.Value == -1) {
                                features = features + '<li><strong>' + feature.Description + '</strong> ' + feature.FeatureName + '</li>';
                            }
                            else {
                                features = features + '<li><strong>' + feature.Value + '</strong> ' + feature.FeatureName + '</li>';
                            }
                        }
                    }

                    if (packagedetails.MonthlyAmount > 0) {
                        price = packagedetails.CurrencySign + ' ' + packagedetails.MonthlyAmount;
                    }
                    else {
                        price = 'Free';
                    }

                    if (packagedetails.IsPopular) {
                        divpackage = '<div class="col-md-3 col-sm-6 center">' +
                                        '<div class="plan most-popular">' +
                                            '<div class="plan-ribbon-wrapper"><div class="plan-ribbon">Popular</div></div>' +
                                                '<h3>' + packagedetails.PackageName + '<span>' + price + '</span></h3>' +
                                                '<a class="btn btn-lg btn-primary" href="/register/' + packagedetails.PackageName.toLowerCase() + '">Signup</a>' +
                                                '<input type="hidden" id="hiddenpackageid" value="' + packagedetails.PackageId + '" />' +
                                                '<ul>' + features + '</ul>' +
                                        '</div>' +
                                    '</div>';
                    }
                    else {
                        divpackage = '<div class="col-md-3 col-sm-6">' +
                                        '<div class="plan">' +
                                                '<h3>' + packagedetails.PackageName + '<span>' + price + '</span></h3>' +
                                                '<a class="btn btn-lg btn-primary" href="/register/' + packagedetails.PackageName.toLowerCase() + '">Signup</a>' +
                                                '<input type="hidden" id="hiddenpackageid" value="' + packagedetails.PackageId + '" />' +
                                                '<ul>' + features + '</ul>' +
                                        '</div>' +
                                    '</div>';
                    }

                    $('#divpackages').append(divpackage);
                }
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}