(function () {

    //console.log('[INJECT] DigitalTouchPoint.WebApi.Scripts.Smashbuckle.js');
    
    console.log('[INJECT] DigitalData.WebApiStarter.CustomContent.basic-auth.js');



    $('#Authentication_Authentication_SignInAsync .response_headers').bind('DOMSubtreeModified', function (e) {
        if (e.target.innerHTML && e.target.innerHTML.length > 0) {
            var matches = e.target.innerHTML.match(/"(Bearer.+?)",/);            
            console.log(e.target.innerHTML);
            if (!matches || matches.length < 1) {
                console.log('1');
                var token = '';
            }
            else {
                console.log('2');
                var token = matches[1];
            }
            $('[name=Authorization]').val(token);
            $('[name=token]').val(token);
        }
    });
    
    $('textarea').on('keydown', function (event) {
        if ((event.keyCode == 10 || event.keyCode == 13) && event.ctrlKey) {
            $(this).closest('form').find('.submit').click();
        }
    });
    
    (function () {
        var section = $("#Authentication_Authentication_SignInAsync_content");
        section.find("textarea").text("{\n  \"username\": \"birobiro\",\n  \"password\": \"birobiro\"\n}");
        section.find("form").submit();
    })();    

})();