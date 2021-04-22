//variables
var text = 'Hello+World';
var chat_id = '-4321432';
var token = '1213232159:AFanfvdjrenfdv_MJsjesk345jfdsks';

//Function
function sendMessage(text, chat_id, token){
    $.ajax({
        type:'POST',
        url: 'https://api.telegram.org/bot' + token + '/sendMessage?chat_id=' + chat_id + '&text=' + text,
        cache:false,
         dataType:'JSONP',
        success: function(data) {
            //Get return JSON and display results
           if(data.ok == true)
           {
              alert('Success: return 0');
              console.log('Done');        
           } else 
           {
              alert('Failure: return 1');
           }
   },
        });
}

//Run code
sendMessage(text, chat_id, token);