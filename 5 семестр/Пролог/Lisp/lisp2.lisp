(defun rep(L)
	(cond ((null L) nil)
	       ((equal (car L) (cdar L)) (rep (cons (car L) (remove (car L) (cdr L)))))
	       (t (cons (car L) (rep (cdr L))))))
