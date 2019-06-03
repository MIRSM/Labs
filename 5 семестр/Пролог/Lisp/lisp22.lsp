(defun rep(L)
	(cond ((null L) nil)
	      ((equal (car L) (cadr L)) (rep (cons (car L) (remove (car L) (cdr L)))))
	       (t (cons (car L) (rep (cdr L))))))

(rep '(2 3 3 1 8))
