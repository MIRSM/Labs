(defun F (l x)
	(if l
	((lambda (head result)
	(cond 
	((equal head x) result)
	((listp head) (cons (F head x) result))
	(t (cons head result))))
	(car l)
	(F (cdr l) x))))
	
(setq l '(1 2 1 1 3 1 2 1))
(print (F l 1))
(print l)