(function () {

    console.log('[INJECT] DigitalData.WebApi.Scripts.Smashbuckle.js');

    $('#Authentication_Authentication_SignInAsync .response_headers').bind('DOMSubtreeModified', function (e) {
        if (e.target.innerHTML && e.target.innerHTML.length > 0) {
            var matches = e.target.innerHTML.match(/"(Bearer.+?)",/);
            if (!matches || matches.length < 1)
                var token = '';
            else
                var token = matches[1];
            $('[name=Authorization]').val(token);
            $('[name=token]').val(token);
        }
    });

    $('textarea').on('keydown', function (event) {
        if ((event.keyCode == 10 || event.keyCode == 13) && event.ctrlKey) {
            $(this).closest('form').find('.submit').click();
        }
    });

    (function() {
        var section = $("#Authentication_Authentication_SignInAsync_content");
        section.find("textarea").text("{\n  \"username\": \"renator\",\n  \"password\": \"Daimler2021\"\n}");
        section.find("form").submit();
    })();

})();