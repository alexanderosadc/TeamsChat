-module(database).

-behaviour(gen_server).
-export([send_message/1, start_link/0, init/1 ,handle_cast/2]).

start_link() ->
    gen_server:start_link({local, database}, ?MODULE, [], []).

init([]) ->
    ets:new(json, [set, named_table]),
    {ok, []}.

send_message(Message) ->
    gen_server:cast(?MODULE, {send_message, Message}).


handle_cast({send_message, Message}, State) ->
     % io:format("~p~p ~n", ["Database =", ListOfMaps]),
    add_to_database(Message),
    Infomration = ets:info(json),
    Size = lists:keyfind(size, 1, Infomration),
    io:format("~p~p ~n", ["Size Json", ets:last(json)]),
    {noreply, State}.


add_to_database({Json, Root}) ->
    ObjectToSave = {Json, Root},
    % erlang:start_timer(5000, ),
    io:format("~p~p ~n", ["Tuple =", ObjectToSave]),
    % io:format("~p~p ~n", ["Database =", TweetMap]),

    ets:insert(json, ObjectToSave).

update_time(Length) when Length > 0 ->
    Item = ets:first(json),
    {_, _, Timeout} = Item,
    ets:delete(json, 1),
    ets:insert();
update_time(_)->
    ok.
    