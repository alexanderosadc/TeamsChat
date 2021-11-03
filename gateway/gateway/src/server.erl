-module(server).

-export([init/2]).

init(Req, Opts) ->
    Req = cowboy_req:reply(200, #{
        <<"content-type">> => <<"text/plain">>
    }, <<"Hello World!">>, Req),
    {cowboy_rest, Req, Opts}.