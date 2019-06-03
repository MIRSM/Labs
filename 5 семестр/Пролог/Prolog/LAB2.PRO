/*Ugrovatov,Lyalin*/
predicates
	parent(String,String)
	male(String)
	female(String)
	mother(String,String)
	father(String,String)
	brother(String,String)
	sister(String,String)
	grandMother(String,String)
	grandFather(String,String)
	cousen(String,String)
	sisOrBro(String,String)
	wife(String,String)
	husbend(String,String)
	uncle(String,String)
	aunt(String,String)
	plem(String,String)
	printBrothers
	printSisters
	printMother
	printFather
	printCousens
	printGrandMothers
	printGrandFathers
clauses
	parent("Valya","Lena").
	parent("Valya","Maya").
	parent("Valya","Andrey").	
	
	parent("Viktor","Lena").
	parent("Viktor","Maya").
	parent("Viktor","Andrey").	
	
	parent("Sveta","Vladimir").
	parent("Sveta","Irina").	
	
	parent("Alexandr","Vladimir").
	parent("Alexandr","Irina").
	
	parent("Maya","Dmitry").
	parent("Maya","Stas").
	parent("Vladimir","Dmitry").
	parent("Vladimir","Stas").
	parent("Lena","Dasha").
	parent("Lena","Pasha").
	parent("Misha","Pasha").
	parent("Misha","Dasha").
	parent("Irina","Olga").
	
	female("Olga").
	female("Dasha").
	female("Valya").
	female("Maya").
	female("Lena").
	female("Sveta").
	female("Irina").
	male("Misha").
	male("Pasha").
	male("Alexandr").	
	male("Vladimir").
	male("Viktor").
	male("Andrey").
	male("Dmitry").
	male("Stas").
	
	mother(X,Y):-parent(X,Y),female(X).
	father(X,Y):-parent(X,Y),male(X).
	grandMother(X,Y):-parent(Z,Y),parent(X,Z),female(X).
	grandFather(X,Y):-parent(Z,Y),parent(X,Z),male(X).
	brother(X,Y):-parent(Z,X),parent(Z,Y),male(Z),male(X),X<>Y.
	sister(X,Y):-parent(Z,X),parent(Z,Y),male(Z),female(X),X<>Y.
	sisOrBro(X,Y):-sister(X,Y),X<>Y;brother(X,Y),X<>Y.
	aunt(X,Y):-parent(A,Y),sisOrBro(A,X).
	uncle(X,Y):-parent(A,Y),brother(X,A).
	plem(X,Y):-parent(A,X),sisOrBro(A,Y),female(X).
	
	cousen(X,Y):-parent(A,X),parent(B,Y),sisOrBro(A,B).
	wife(X,Y):-parent(X,A),parent(Y,A),female(X),X<>Y.
	husbend(X,Y):-parent(X,A),parent(Y,A),male(X),X<>Y.
	
	printCousens:-cousen(X,Y),write(X," - cousen - ",Y),nl,fail.
	printFather:-father(X,Y),write(X," - otec - ",Y),nl,fail.
	printMother:-mother(X,Y),write(X," - mat - ",Y),nl,fail.
	printSisters:-sister(X,Y),write(X," - sestra - ",Y),nl,fail.
	printBrothers:-brother(X,Y),write(X," - brat - ",Y),nl,fail.
	printGrandFathers:-grandFather(X,Y),write(X," - ded - ",Y),nl,fail.
	printGrandMothers:-grandMother(X,Y),write(X," - babuska - ",Y),nl,fail.
	