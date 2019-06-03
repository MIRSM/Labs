(defun myRepl(l x)
	(cond ((null l)
		nil)
	((cond (((car l) x)
		((rplaca l (cadr l)) (rplacd l (cddr l)) (myRepl (cdr l) x))
		)(myRepl (cdr l) x))
	)))
		
	

(setq lst '(1 4 1 1 2 1 4 1 5 2 6 2))
(myRepl lst 1)
(print lst)
