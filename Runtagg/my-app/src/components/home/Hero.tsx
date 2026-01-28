"use client";

import { motion } from "framer-motion";

const floatTransition = {
  duration: 4,
  repeat: Infinity,
  repeatType: "reverse" as const,
  ease: "easeInOut",
};

export default function Hero() {
  return (
    <section
      id="top"
      className="flex min-h-[80vh] flex-col items-center gap-12 pt-10 lg:min-h-[88vh] lg:flex-row lg:items-center lg:gap-16"
    >
      <motion.div
        initial={{ opacity: 0, y: 24 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.7, ease: "easeOut" }}
        className="relative z-10 flex-1 space-y-8"
      >
        <div className="inline-flex items-center gap-3 rounded-full border border-white/10 bg-white/5 px-4 py-1 text-[11px] uppercase tracking-[0.24em] text-slate-300 backdrop-blur-2xl">
          <span className="h-1.5 w-1.5 rounded-full bg-gradient-to-r from-[#7C3AED] to-[#38BDF8]" />
          <span className="text-[10px] font-semibold">Tech Studio</span>
          <span className="text-[10px] text-slate-400">Game · Web · AI</span>
        </div>

        <div className="space-y-4">
          <h1 className="text-balance text-4xl font-semibold uppercase tracking-[0.16em] text-slate-100 sm:text-5xl lg:text-6xl">
            We build crews,
            <br />
            <span className="accent-text-gradient">they build products.</span>
          </h1>
          <p className="max-w-xl text-sm leading-relaxed text-slate-300 sm:text-base">
            A liquid-glass tech studio where developers, designers and makers
            team up to ship games, web apps and competition projects. Small,
            focused crews. High-trust, high-output environments.
          </p>
        </div>

        <div className="space-y-4">
          <div className="flex flex-wrap items-center gap-4">
            <a
              href="#join"
              className="group relative inline-flex items-center justify-center overflow-hidden rounded-full px-6 py-2.5 text-xs font-semibold uppercase tracking-[0.25em] text-white"
            >
              <span className="absolute inset-0 accent-gradient opacity-90 transition duration-300 group-hover:opacity-100" />
              <span className="absolute inset-0 bg-white/10 opacity-0 blur-xl transition duration-300 group-hover:opacity-70" />
              <span className="relative">Join a Crew</span>
            </a>

            <a
              href="#projects"
              className="inline-flex items-center justify-center rounded-full border border-white/20 px-6 py-2.5 text-xs font-semibold uppercase tracking-[0.25em] text-slate-200/90 transition hover:border-sky-400/70 hover:text-sky-200"
            >
              View Projects
            </a>
          </div>
          <p className="text-[11px] text-slate-400">
            No CV. Just your GitHub, itch.io, Behance or portfolio.
          </p>
        </div>

        <div className="mt-6 flex items-center gap-3 text-[11px] text-slate-400">
          <span className="inline-flex h-6 w-6 items-center justify-center rounded-full bg-white/5 text-[13px]">
            ☆
          </span>
          <p className="max-w-md">
            Game, web &amp; AI teams · Teknofest &amp; global hackathons ·
            Remote-friendly crews
          </p>
        </div>
      </motion.div>

      <motion.div
        initial={{ opacity: 0, scale: 0.9, filter: "blur(10px)" }}
        animate={{ opacity: 1, scale: 1, filter: "blur(0px)" }}
        transition={{ duration: 0.8, ease: "easeOut", delay: 0.1 }}
        className="relative z-10 flex flex-1 items-center justify-center"
      >
        <div className="relative w-full max-w-md">
          <div className="absolute -inset-10 -z-10 rounded-[40px] bg-[radial-gradient(circle_at_0%_0%,rgba(124,58,237,0.3),transparent_55%),radial-gradient(circle_at_100%_100%,rgba(56,189,248,0.3),transparent_55%)] opacity-80 blur-3xl" />

          <div className="glass-panel relative overflow-hidden rounded-[36px] border-white/15 bg-gradient-to-br from-white/10 via-white/5 to-white/0 p-[1px]">
            <div className="relative h-full w-full rounded-[34px] bg-gradient-to-b from-slate-900/80 via-slate-900/60 to-slate-950/95 p-8">
              <div className="pointer-events-none absolute inset-0 bg-[radial-gradient(circle_at_20%_0%,rgba(148,163,253,0.7),transparent_55%),radial-gradient(circle_at_80%_100%,rgba(56,189,248,0.6),transparent_55%)] mix-blend-screen opacity-70" />

              <div className="relative flex flex-col items-center gap-6">
                <div className="relative flex h-32 w-32 items-center justify-center overflow-hidden rounded-[32px] border border-white/25 bg-gradient-to-br from-slate-900/90 via-slate-800/70 to-slate-950 shadow-[0_26px_80px_rgba(0,0,0,0.9)]">
                  <div className="pointer-events-none absolute inset-0 bg-[radial-gradient(circle_at_0%_0%,rgba(248,250,252,0.45),transparent_45%),radial-gradient(circle_at_100%_100%,rgba(56,189,248,0.5),transparent_45%)] mix-blend-screen opacity-90" />
                  <span className="relative text-4xl font-semibold tracking-[0.32em] text-slate-950 drop-shadow-[0_0_30px_rgba(15,23,42,0.8)]">
                    R
                  </span>
                </div>

                <p className="text-center text-[11px] uppercase tracking-[0.3em] text-slate-300/90">
                  Liquid Glass Tech Studio
                </p>

                <div className="relative mt-2 grid w-full grid-cols-3 gap-3 text-xs text-slate-100">
                  <motion.div
                    animate={{ y: [0, -8, 0] }}
                    transition={floatTransition}
                    className="glass-chip flex flex-col items-center gap-1 px-3 py-2"
                  >
                    <span className="text-[11px] font-semibold uppercase tracking-[0.2em]">
                      Game Crew
                    </span>
                    <span className="text-[10px] text-slate-400">
                      Unity · Unreal · Godot
                    </span>
                  </motion.div>
                  <motion.div
                    animate={{ y: [0, -10, 0] }}
                    transition={{ ...floatTransition, duration: 4.4 }}
                    className="glass-chip flex flex-col items-center gap-1 px-3 py-2"
                  >
                    <span className="text-[11px] font-semibold uppercase tracking-[0.2em]">
                      Web Crew
                    </span>
                    <span className="text-[10px] text-slate-400">
                      Next.js · Django · FastAPI
                    </span>
                  </motion.div>
                  <motion.div
                    animate={{ y: [0, -7, 0] }}
                    transition={{ ...floatTransition, duration: 4.7 }}
                    className="glass-chip flex flex-col items-center gap-1 px-3 py-2"
                  >
                    <span className="text-[11px] font-semibold uppercase tracking-[0.2em]">
                      AI / Comp.
                    </span>
                    <span className="text-[10px] text-slate-400">
                      Teknofest · Hackathons
                    </span>
                  </motion.div>
                </div>

                <div className="mt-6 h-24 w-full overflow-hidden rounded-3xl border border-white/10 bg-gradient-to-b from-slate-900/50 via-slate-900/80 to-slate-950/95">
                  <div className="relative h-full w-full">
                    <div className="absolute inset-0 bg-[linear-gradient(to_bottom,rgba(148,163,184,0.22)_1px,transparent_1px),linear-gradient(to_right,rgba(148,163,184,0.18)_1px,transparent_1px)] bg-[size:40px_40px] opacity-30" />
                    <div className="absolute inset-0 bg-gradient-to-b from-transparent via-slate-950/10 to-slate-950/80" />
                    <div className="absolute inset-0 flex items-end justify-between px-4 pb-3 text-[10px] text-slate-400">
                      <span>Crews online · 3</span>
                      <span>Next sprint: 02/2026</span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </motion.div>
    </section>
  );
}

