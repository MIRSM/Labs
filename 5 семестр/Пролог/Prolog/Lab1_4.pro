/* Ugrovatov, Lyalin*/
domains
predicates
	inv(integer,integer).
	con(integer,integer,integer).
	do(integer).
clauses
	inv(1,0).
	inv(0,1).
	con(1,1,0).
	con(1,0,1).
	con(0,1,1).
	con(0,0,1).
	do(1).
	do(0).
goal
	do(Y),
	con(X1,X2,Y1),
	con(Y1,X2,Y2),
	con(X3,X4,Y3),
	inv(Y3,Y4),
	con(Y2,Y4,Y),
	write("Y-> ",Y," ",X1,X2,X3,X4),nl,fail.