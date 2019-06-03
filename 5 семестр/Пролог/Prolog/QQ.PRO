/*Индекс с какого начинается полиндром, и его длину надо запомнить*/
domains
il=integer*
predicates
nondeterm palindrom(il,il,integer)
nondeterm palindrom(il,il)
nondeterm podspisok(il,il,integer)
nondeterm prefiks(il,il)
revers(il,il,il)
replace(integer,il,il,integer,il)
write_list(il)
deeper(il,integer)
clauses
palindrom(L,P,R):- I=1,podspisok(L,P,I),write(I), revers(P,[],P),deeper(P,R),R>1,!.

palindrom(L,P):-palindrom(L,D,R),nl,write_list(P).

replace(_,[],_,_,[]).
replace(X,[X|L],[X|D],0,[0|M]):-!,replace(X,L,D,0,M).
replace(X,[Y|L],[X|D],0,[Y|M]):-replace(X,L,D,0,M).

deeper([],0).
deeper([_|T],R):-deeper(T,NR),R=NR+1.


revers([],L,L):-!.
revers([H|L],T,R):- revers(L,[H|T],R).

podspisok([H|L],[H|T],I):- prefiks(L,T).
podspisok([_|L],T,I):- NewI=I+1,podspisok(L,T,NewI).

prefiks(_,[]).
prefiks([H|L],[H|T]):- prefiks(L,T).

write_list([]):-nl. 
	write_list([H|T]):-write(H),write_list(T).

goal
write("new"),nl,palindrom([1,2,3,4,3,2,1],P).