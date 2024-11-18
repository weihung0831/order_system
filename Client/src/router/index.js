import { createRouter, createWebHistory } from 'vue-router';
import AdminLogin from '@/components/AdminLogin.vue';
import UserLogin from '@/components/UserLogin.vue';
import Test from '@/components/test.vue';

const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/', redirect: '/login' },
        { path: '/admin/login', component: AdminLogin },
        { path: '/login', component: UserLogin },
        {
            path: '/test',
            component: Test,
            meta: { requiresAuth: true }
        },
    ],
});

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.requiresAuth)) {
        if (!localStorage.getItem('adminSession') && !localStorage.getItem('userSession')) {
            if (to.path.startsWith('/admin/')) {
                next('/admin/login');
            } else {
                next('/login')
            }
        } else {
            next();
        }
    } else {
        next();
    }
});

export default router;