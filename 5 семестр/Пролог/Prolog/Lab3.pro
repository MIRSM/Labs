/*сформировать список из элементов, вводимых с клавиатуры*/
/*формировать список с головы и с конца*/
domains
	list=integer*
predicates	
	readList(list).
	write_list(list).
clauses
	readList([H|T]):-write("Vvedite element->"), readint(H),!,readList(T).
	readList([]).
	write_list([]):-nl. 
	write_list([H|T]):-write(H),write_list(T).
	
goal
	readList(L),nl,write("Spisok:"),nl,write_list(L).