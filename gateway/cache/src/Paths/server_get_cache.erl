-module(server_get_cache).

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
	io:format("Ia zashel:~p~n", [HandlerName]),
	% Response = database:get_data(HandlerName),
	Body = <<"Blahblahbbash">>,
	{Body, Req, HandlerName}.

to_text(Req, State) ->
	{<<"REST Hello World as text!">>, Req, State}.
