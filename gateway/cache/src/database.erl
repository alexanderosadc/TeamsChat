-module(database).

-behaviour(gen_server).
-export([send_message/1, start_link/0, init/1 ,handle_cast/2, handle_info/2, get_data/1]).

start_link() ->
    gen_server:start_link({local, database}, ?MODULE, [], []).

init([]) ->
    Index = 1,
    ets:new(cache_db, [set, named_table]),
    {ok, Index}.

send_message(Message) ->
    gen_server:cast(?MODULE, {send_message, Message}).

handle_info({_, _, IndexToSearch}, State) ->
    ets:match_delete(cache_db, {'_', '_', IndexToSearch}),
    {noreply, State}.

handle_cast({send_message, Message}, Index) ->
    io:format("~p~p ~n", ["Size Json", Index]),
    add_to_database(Message, Index),
    NewIndex = Index + 1,
    % io:format("~p~p ~n", ["Size Json", ets:last(json)]),
    {noreply, NewIndex}.


add_to_database({Json, Root}, Index) ->
    ObjectToSave = {Json, Root, Index},
    ets:insert(cache_db, ObjectToSave),
    erlang:start_timer(10000, database, Index).

get_data(Root) ->
    MatchedValues = ets:match(cache_db, {'_', Root, '_'}),
    Response = return_data(MatchedValues),
    io:format("~p~p ~n", ["Matched JSON", Response]),
    Response.

return_data(ExtractedData) when length(ExtractedData) > 0 ->
    ExtractedData;
return_data(ExtractedData) ->
    0.