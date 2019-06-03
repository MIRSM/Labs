/*
Laboratornaya rabota #5
Ugrovatpv, Lyalin
Zadanie: poschitat' kol-vo elemenmtov na N yrovne dereva
*/
domains
treetype = tree(integer,treetype,treetype);empty()
predicates
tree1(treetype)
rbt_count_nodes(treetype,integer,integer,integer)
clauses
tree1(tree(1,
			tree(2,
				tree(4,empty,empty),
				tree(5,empty,empty)),
			tree(3,
				tree(6,
					tree(8,empty,empty),
				empty),
				tree(7,empty,empty))
		)
	).
rbt_count_nodes(empty,_,_,0):-!.
rbt_count_nodes(_,I,I,1):-!.
rbt_count_nodes(tree(_,L,R),C,I,N):-
	New_C=C+1,
	rbt_count_nodes(L,New_C,I,NL),
	rbt_count_nodes(R,New_C,I,NR),
	N=NL+NR.
goal
	tree1(T),rbt_count_nodes(T,0,2,N),write(N).