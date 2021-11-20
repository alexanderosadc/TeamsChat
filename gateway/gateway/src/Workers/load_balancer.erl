-module(load_balancer).

-behaviour(gen_server).

-export([start_link/0, init/1, handle_call/3, handle_cast/2, handle_info/2, call_worker/2]).

start_link() ->
    gen_server:start_link({local, ?MODULE}, ?MODULE, [], []).

init([]) ->
    GetAllChatsList = [],
    {ok, [GetAllChatsList]}.

handle_call([Req, HandlerName], _From, State) ->
    io:format("~p: ~p", ["Name:", HandlerName]),
    {reply, "Connected", []}.

handle_cast(_, State) ->
    {noreply, State}.

handle_info(_, State) ->
    {noreply, State}.

call_worker(Req, HandlerName) ->
    gen_server:call(?MODULE, [Req, HandlerName]).

add_request_to_list(Req, get_all_chats, State) ->
    State:nth(1, State).