<?php

// https://github.com/php-telegram-bot/core#send-message
$result = Request::sendMessage([
    'chat_id' => $chat_id,
    'text'    => 'Your utf8 text 😜 ...',
]);

?>