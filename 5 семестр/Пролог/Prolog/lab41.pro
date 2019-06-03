domains
	list=integer*
predicates
	length(list,integer,integer).
	delete(list,integer,list).
	write_list(list).
clauses
	delete(_,N,[]):-N<=0.
	delete([H|T],N,[H|X]):-N>0,N1=N-1,delete(T,N1,X).
	
	length([],A,A).
	length([H|T],A,D):-New_A=A+1,length(T,New_A,D).
	
	write_list([]):-nl. 
	write_list([H|T]):-write(H),write_list(T).
goal
	L=[1,2,3,4,5,6],
	length(L,0,D),D1=D-4,delete(L,D1,X),write_list(X).