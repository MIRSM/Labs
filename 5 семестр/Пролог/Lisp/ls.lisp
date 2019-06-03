(defun schet (n)
  (spisok n 0)
  )

(defun podspisok (n m)
  (cond ((= m 0) nil)
        (t (cons n (podspisok n (- m 1))))))

(defun mkvch (n k)
  (cond ((= k n) (podspisok n n))
        (t (nconc (podspisok k k) (list (mkvch n (+ k 1)))))))
