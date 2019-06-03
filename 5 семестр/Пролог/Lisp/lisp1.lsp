(defun func (a x)
    (setq a (nconc `(1) a))
    (func2 a x)
    ;(print (cdr a))     
)

(defun func2 (a x)
    (if (NULL (cdr a)) 
        NIL
        (if (= (cadr a) x)
            (func2 (rplacd a (cddr a)) x)
            (func2 (cdr a) x)
        )

    )   
)

(setq l '(1 1 2 1 2 2 4 1))
(func l 2)
(print l)