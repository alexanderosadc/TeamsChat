-module(server_get_all_chats).

-export([init/2, content_types_provided/2, to_html/2, to_json/2, to_text/2]).

init(Req, State) ->
    % io:format("~p: ~p~n", ["Request:", Req]),
    % Body = <<"Hello World">>,
    % Reply = cowboy_req:reply(200, #{
    %     <<"content-type">> => <<"text/plain">>
    % }, Body, Req),
    {cowboy_rest, Req, State}.

content_types_provided(Req, State) ->
	{[
		{<<"text/html">>, to_html},
		{<<"application/json">>, to_json},
		{<<"text/plain">>, to_text}
	], Req, State}.

to_html(Req, State) ->
	Body = 
<<"<html>
<head>
	<meta charset=\"utf-8\">
	<title>REST Hello World!</title>
</head>
<body>
	<p>asfhasjkfhkajs</p>
</body>
</html>">>,
	{Body, Req, State}.

to_json(Req, HandlerName) ->
	% load_balancer:call_worker(Req, HandlerName),
	Body = <<"{\"rest\": \"get_all_chats\"}">>,
	inets:start(),
	{ok, {{Version, 200, ReasonPhrase}, Headers, Bodys}} = 
		httpc:request(get, {"http://www.erlang.org", []}, [], []),
	inets:stop(),
	io:format("~p", ["HAHAHAHAHAHAHAHHAHAHAHHAH"]),
	{Bodys, Req, HandlerName}.

to_text(Req, State) ->
	{<<"REST Hello World as text!">>, Req, State}.