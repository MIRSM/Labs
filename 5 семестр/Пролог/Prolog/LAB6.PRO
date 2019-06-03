domains
list=integer*
predicates
reverse(list,list,list)
reverse(list,list)
write_list(list)
/*go_deeper(list,list)*/
clauses


/*go_deeper([H|T]):-*/

reverse(L,R):-reverse(L,[],R).

reverse([],L,L):-!.
reverse([H|T],L,R):-reverse(T,[H|L],R).

write_list([]):-nl. 
	write_list([H|T]):-write(H),write_list(T).
goal
L=[1,2,3,4,5],reverse(L,R),L=R,write_list(L),write_list(R).