/*сформировать список из элементов, вводимых с клавиатуры*/
/*формировать список с конца*/
domains
	list=integer*
predicates	
	readList(list,list).
	write_list(list).
clauses
	readList([H|T],A):-readint(H),T=A,readList([H|T],T). 
	readList([H|T],[]):-readint(H),readList([H|T],H).
	
	write_list([]):-nl. 
	write_list([H|T]):-write(H),write_list(T).
	
goal
	readList([],[]),nl,write("Spisok:"),nl,write_list(L).