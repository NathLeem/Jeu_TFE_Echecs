<?php
    session_start();
    require_once 'element/header.php';

    $uri = $_SERVER['REQUEST_URI'];
    if($uri === '/index.php'){
        require_once 'view/reception.php';
    }
    elseif($uri === 'Regle_jeu/index.php?/views/pawn.php'){
        require_once 'view/pawn.php';
    }
    elseif($uri === 'Regle_jeu/index.php?/views/bishop.php'){
        require_once 'view/bishop.php';
    }
    elseif($uri === 'Regle_jeu/index.php?/views/tower.php'){
        require_once 'view/tower.php';
    }
    elseif($uri === 'Regle_jeu/index.php?/views/queen.php'){
        require_once 'view/queen.php';
    }
    elseif($uri === 'Regle_jeu/index.php?/views/king.php'){
        require_once 'view/king.php';
    }
    elseif($uri === 'Regle_jeu/index.php?/views/horse.php'){
        require_once 'view/horse.php';
    }

    require_once 'element/footer.php';
?>

</body>
</html>