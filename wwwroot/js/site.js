
// Write your JavaScript code.

// Active menu script - BEGIN
$(document).ready(function () {

    var url = window.location.href;
    url = url.substring(0, (url.indexOf("#") == -1) ? url.length : url.indexOf("#"));
    url = url.substring(0, (url.indexOf("?") == -1) ? url.length : url.indexOf("?"));
    url = url.substr(url.lastIndexOf("/") + 1);

    // If file name not avilable
    if (url == '') {
        url = '';
    }

    // Loop all menu items
    $('.menu li ').each(function () {

        // select href
        var href = $(this).find('a').attr('href');

        
        // Check filename
        href = href.substr(href.lastIndexOf("/") + 1)
        
        if (url == href) {

            // Add active class
            $(this).addClass('active');
        }
    });
});

// Active menu script - END

