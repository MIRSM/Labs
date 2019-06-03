/*	Угроватов, Лялин
	Лабораторная работа №4, Вариант №7:
	Удалить из списка заданное число последних элементов.
*/

domains
	list=integer*
predicates
	delete(list,integer,integer,integer,list).
	delete1(list,integer,integer,integer,list).
	write_list(list).
clauses
	delete(L,I,A,D,X):-delete1(L,I,A,D,X).
	
	delete1([],_,A,A,[]).
	delete1([_|T],I,A,D,X):-New_A=A+1,delete1(T,I,New_A,D,X),New_A>D-I.
	delete1([H|_],I,A,D,[H|X]):-A<=D-I.
	
	/*общий счетчик 
	A>=D-I заносим в список*/
	
	write_list([]):-nl. 
	write_list([H|T]):-write(H),write_list(T).
goal
	delete([1,2,3,4,5,6],4,0,D,X),nl,write_list(X).