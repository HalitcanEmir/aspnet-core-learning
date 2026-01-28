"use client";

import { motion, useScroll, useMotionValueEvent } from "framer-motion";
import { useState } from "react";

const navItems = [
  { label: "Home", href: "#top" },
  { label: "Projects", href: "#projects" },
  { label: "Crews", href: "#crews" },
  { label: "About", href: "#process" },
  { label: "Join", href: "#join" },
];

export default function Navbar() {
  const [scrolled, setScrolled] = useState(false);
  const { scrollY } = useScroll();

  useMotionValueEvent(scrollY, "change", (latest) => {
    setScrolled(latest > 24);
  });

  return (
    <motion.header
      initial={{ y: -40, opacity: 0 }}
      animate={{ y: 0, opacity: 1 }}
      transition={{ duration: 0.6, ease: "easeOut" }}
      className="fixed inset-x-0 top-0 z-40 flex justify-center"
    >
      <motion.nav
        animate={{
          height: scrolled ? 64 : 76,
          opacity: scrolled ? 1 : 0.95,
        }}
        transition={{ duration: 0.25 }}
        className="mt-4 flex w-full max-w-6xl items-center justify-between rounded-3xl border border-white/10 bg-black/40 px-4 text-sm text-slate-100 shadow-[0_18px_60px_rgba(0,0,0,0.65)] backdrop-blur-xl sm:px-6"
      >
        <div className="flex items-center gap-3">
          <div className="relative flex h-10 w-10 items-center justify-center overflow-hidden rounded-2xl border border-white/20 bg-gradient-to-br from-slate-900/80 via-slate-800/60 to-slate-900/90 shadow-[0_18px_60px_rgba(0,0,0,0.85)]">
            <div className="pointer-events-none absolute inset-0 bg-[radial-gradient(circle_at_0%_0%,rgba(148,163,253,0.55),transparent_55%),radial-gradient(circle_at_100%_100%,rgba(56,189,248,0.55),transparent_55%)] mix-blend-screen opacity-70" />
            <span className="relative text-lg font-semibold tracking-[0.22em] text-slate-100">
              R
            </span>
          </div>
          <div className="hidden flex-col sm:flex">
            <span className="text-[11px] uppercase tracking-[0.28em] text-slate-400">
              Liquid Glass
            </span>
            <span className="text-xs text-slate-200">
              Crew-based tech studio
            </span>
          </div>
        </div>

        <div className="hidden items-center gap-8 md:flex">
          <div className="flex items-center gap-6 text-xs font-medium uppercase tracking-[0.25em] text-slate-300">
            {navItems.map((item) => (
              <a
                key={item.href}
                href={item.href}
                className="group relative pb-1 transition-colors hover:text-slate-50"
              >
                <span>{item.label}</span>
                <span className="pointer-events-none absolute inset-x-0 -bottom-1 h-px origin-center scale-x-0 bg-gradient-to-r from-[#7C3AED] via-sky-400 to-[#38BDF8] opacity-0 transition-all duration-200 group-hover:scale-x-100 group-hover:opacity-100" />
              </a>
            ))}
          </div>
          <a
            href="#join"
            className="group relative inline-flex items-center justify-center overflow-hidden rounded-full px-5 py-2 text-xs font-semibold uppercase tracking-[0.25em] text-white"
          >
            <span className="absolute inset-0 accent-gradient opacity-90 transition duration-300 group-hover:opacity-100" />
            <span className="absolute inset-0 bg-white/10 opacity-0 blur-xl transition duration-300 group-hover:opacity-60" />
            <span className="relative">Join a Crew</span>
          </a>
        </div>

        <div className="flex items-center gap-2 md:hidden">
          <a
            href="#join"
            className="accent-gradient inline-flex items-center justify-center rounded-full px-4 py-2 text-[11px] font-semibold uppercase tracking-[0.25em] text-white shadow-[0_18px_60px_rgba(0,0,0,0.65)]"
          >
            Join
          </a>
        </div>
      </motion.nav>
    </motion.header>
  );
}

