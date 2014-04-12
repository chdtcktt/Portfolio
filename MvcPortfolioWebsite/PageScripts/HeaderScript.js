/// <reference path="../../Scripts/_references.js" />
/// <reference path="../../Scripts/jquery.slicknav.min.js" />
$(document).ready(function () {


    //custom jquery plugin loadText()
    $.fn.loadText = function (textArray, interval) {
        return this.each(function () {
            var obj = $(this);
            obj.slideUp('slow', function () {
                var elem = textArray[0];
                obj.empty().html(elem);
                textArray.shift();
                textArray.push(elem);
                obj.slideDown('slow');
            });
            timeOut = setTimeout(function () { obj.loadText(textArray, interval) }, interval);



        });
    };

    //array for nav
    var helloArray =
        [
            "I like .NET",
            "I love new challenges",
            "I have a wonderful wife",
            "I am a transplant from Louisiana",
            "I am out of things to say",
        ];
    //load text into text effect
    $('#effect-text').loadText(helloArray, 5000); // ( array, interval )
    document.title = $('#page_title').text();



    //so contact will scroll slowly
    $("a[href='#contact']").click(function () {
        $("html, body").animate({ scrollTop: $(document).height() }, "slow");
        return false;
    });



    //for the mobile responsive nav bar
    $('#menu').slicknav({
        label: '',
        duration: 100,
    });


});